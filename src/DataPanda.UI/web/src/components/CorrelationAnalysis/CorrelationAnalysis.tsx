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
				newCorrelationAnalysisData.correlation = Math.abs(newCorrelationAnalysisData.correlation);
				setCorrelationAnalysisData(newCorrelationAnalysisData);

				if (correlationAnalysisData.correlation < 0) {
					setcorrelationDirection("отрицателна");
				} else {
					setcorrelationDirection("положителна");
				}

				if (correlationAnalysisData.correlation <= 0.3) {
					setcorrelationText("Зависимостта е слаба");
				} else if (correlationAnalysisData.correlation <= 0.5) {
					setcorrelationText("Умерена зависимост");
				} else if (correlationAnalysisData.correlation <= 0.7) {
					setcorrelationText("Значителна зависимост");
				} else if (correlationAnalysisData.correlation <= 0.9) {
					setcorrelationText("Силна зависимост");
				} else if (correlationAnalysisData.correlation > 0.9 || correlationAnalysisData.correlation !== 1) {
					setcorrelationText("Много силна зависимост");
				} else if (correlationAnalysisData.correlation === 1) {
					setcorrelationText("Зависимостта е функционална");
				} else if (correlationAnalysisData.correlation === 0) {
					setcorrelationText("Липсва зависимост");
				}
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
