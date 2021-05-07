import React, { useState } from "react";
import axios from "axios";
import MenuButton from "components/common/Button/MenuButton/MenuButton";
import styles from "./ScatteringMeasures.module.scss";

export class ScatteringMeasuresData {
	swing: number = 0;

	dispersion: number = 0;

	standardDeviation: number = 0;
}

const ScatteringMeasures = () => {
	const [platformNameInput, setPlatformName] = useState("");
	const [courseNameInput, setCourseName] = useState("");
	const [scatteringMeasuresData, setScatteringMeasuresData] = useState<ScatteringMeasuresData>(new ScatteringMeasuresData());

	const onNameOfPlatformChange = (name: string) => {
		setPlatformName(name);
	};

	const onNameOfCourseChange = (name: string) => {
		setCourseName(name);
	};

	const getScatteringMeasuresData = () => {
		if (platformNameInput === "" || courseNameInput === "") {
			alert("Попълни данните!");
			return;
		}

		axios.get(`https://localhost:44364/api/statistics/ScatteringMeasures?courseName=${courseNameInput}&platformName=${platformNameInput}`)
			.then(response => {
				const newScatteringMeasuresData: ScatteringMeasuresData = Object.assign(new ScatteringMeasuresData(), response.data);
				setScatteringMeasuresData(newScatteringMeasuresData);
			});
	};

	return (
		<div>
			<MenuButton />
			<div className={styles.Form}>
				<span>Име на платформата</span>
				<input type="text" placeholder="Име на платформата" value={platformNameInput} onChange={e => onNameOfPlatformChange(e.currentTarget.value)} />
				<span>Име на дисциплината</span>
				<input type="text" placeholder="Име на дисциплината" value={courseNameInput} onChange={e => onNameOfCourseChange(e.currentTarget.value)} />
				<button type="button" className={styles.GetButton} onClick={getScatteringMeasuresData}>Вземи</button>
			</div>
			<table className={styles.Table}>
				<tr>
					<th>Размах</th>
					<th>Дисперсия</th>
					<th>Стандартно отклонение</th>
				</tr>
				<tr>
					<td>{scatteringMeasuresData.swing}</td>
					<td>{scatteringMeasuresData.dispersion}</td>
					<td>{scatteringMeasuresData.standardDeviation}</td>
				</tr>
			</table>
		</div>
	);
};

export default ScatteringMeasures;
