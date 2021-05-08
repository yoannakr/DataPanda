import React, { useState } from "react";
import axios from "axios";
import MenuButton from "components/common/Button/MenuButton/MenuButton";
import styles from "./CorrelationAnalysis.module.scss";
import { IGradeAndWikiEditCorrelations } from "../../models/correlationAnalysis";

export class CorrelationAnalysisData {
	gradeAndWikiEditCorrelations: IGradeAndWikiEditCorrelations[] = [];

	totalGrades: number = 0;

	totalNumberOfWikiEdits: number = 0;

	correlation: number = 0;
}

const CorrelationAnalysis = () => {
	const [courseNameInput, setCourseName] = useState("");
	const [correlationAnalysisData, setCorrelationAnalysisData] = useState<CorrelationAnalysisData>(new CorrelationAnalysisData());
	const [correlationText, setcorrelationText] = useState("");
	const [correlationDirection, setcorrelationDirection] = useState("");

	const onNameOfCourseChange = (name: string) => {
		setCourseName(name);
	};

	const getCorrelationAnalysis = () => {
		if (courseNameInput === "") {
			alert("Попълни данните!");
			return;
		}

		axios.get(`https://localhost:44364/api/statistics/CorrelationAnalysis?courseName=${courseNameInput}`)
			.then(response => {
				const newCorrelationAnalysisData: CorrelationAnalysisData = Object.assign(new CorrelationAnalysisData(), response.data);
				if (newCorrelationAnalysisData.correlation < 0) {
					setcorrelationDirection("отрицателна");
				} else {
					setcorrelationDirection("положителна");
				}

				newCorrelationAnalysisData.correlation = Math.abs(newCorrelationAnalysisData.correlation);
				let tmpCorrelcationText = "";

				if (newCorrelationAnalysisData.correlation <= 0.3) {
					tmpCorrelcationText = "Зависимостта е слаба";
				} else if (newCorrelationAnalysisData.correlation <= 0.5) {
					tmpCorrelcationText = "Умерена зависимост";
				} else if (newCorrelationAnalysisData.correlation <= 0.7) {
					tmpCorrelcationText = "Значителна зависимост";
				} else if (newCorrelationAnalysisData.correlation <= 0.9) {
					tmpCorrelcationText = "Силна зависимост";
				} else if (newCorrelationAnalysisData.correlation > 0.9 || newCorrelationAnalysisData.correlation !== 1) {
					tmpCorrelcationText = "Много силна зависимост";
				} else if (newCorrelationAnalysisData.correlation === 1) {
					tmpCorrelcationText = "Зависимостта е функционална";
				} else if (newCorrelationAnalysisData.correlation === 0) {
					tmpCorrelcationText = "Липсва зависимост";
				}

				setCorrelationAnalysisData(newCorrelationAnalysisData);
				setcorrelationText(tmpCorrelcationText);
			})
			.catch(() => {
				alert("Неуспешно!");
			});
	};

	return (
		<div>
			<MenuButton />
			<div className={styles.Form}>
				<span>Име на дисциплината</span>
				<input type="text" placeholder="Име на дисциплината" value={courseNameInput} onChange={e => onNameOfCourseChange(e.currentTarget.value)} />
				<button type="button" className={styles.GetButton} onClick={getCorrelationAnalysis}>Вземане на данни</button>
			</div>
			<div className={styles.Result}>
				<span>Корелация: </span>
				<span>{correlationAnalysisData.correlation}</span>
				<br />
				<span>Зависимостта e </span>
				<span>{correlationDirection}</span>
				<br />
				<span>{correlationText}</span>
			</div>
			<table className={styles.Table}>
				<tr>
					<th>Студент</th>
					<th>Оценка</th>
					<th>Брой редактирани Wiki</th>
				</tr>
				{correlationAnalysisData.gradeAndWikiEditCorrelations.map(gradeAndWikiEditCorrelation => (
					<tr>
						<td>{gradeAndWikiEditCorrelation.studentId}</td>
						<td>{gradeAndWikiEditCorrelation.grade}</td>
						<td>{gradeAndWikiEditCorrelation.numberOfWikiEdits}</td>
					</tr>
				))}
			</table>
		</div>
	);
};

export default CorrelationAnalysis;
