import React, { useState } from "react";
import axios from "axios";
import MenuButton from "components/common/Button/MenuButton/MenuButton";
import { FrequencyDataDistribution } from "../../models/frequency";
import styles from "./FrequencyDistribution.module.scss";

export class FrequencyData {
	frequencyDistributions: FrequencyDataDistribution[] = [];

	totalAbsoluteFrequency: number = 0;

	totalRelativeFrequency: number = 0;
}

const FrequencyDistribution = () => {
	const [platformNameInput, setPlatformName] = useState("");
	const [courseNameInput, setCourseName] = useState("");
	const [frequencyData, setFrequencyData] = useState<FrequencyData>(new FrequencyData());

	const onNameOfPlatformChange = (name: string) => {
		setPlatformName(name);
	};

	const onNameOfCourseChange = (name: string) => {
		setCourseName(name);
	};

	const getFrequencyDistribution = () => {
		if (platformNameInput === "" || courseNameInput === "") {
			alert("Попълни данните!");
			return;
		}

		axios.get(`https://localhost:44364/api/statistics/FrequencyDistribution?courseName=${courseNameInput}&platformName=${platformNameInput}`)
			.then(response => {
				const newFrequencyData: FrequencyData = Object.assign(new FrequencyData(), response.data);
				setFrequencyData(newFrequencyData);
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
				<button type="button" className={styles.GetButton} onClick={getFrequencyDistribution}>Вземи</button>
			</div>
			{/* {comments.map(comment => (
				<h1>{comment.totalAbsoluteFrequency}</h1>
			))} */}
			<table className={styles.Table}>
				<tr>
					<th>Брой качени файлове </th>
					<th>Абсолютна честота</th>
					<th>Относителна честота</th>
				</tr>
				{frequencyData.frequencyDistributions.map(frequencyDistribution => (
					<tr>
						<td>{frequencyDistribution.numberOfSubmissions}</td>
						<td>{frequencyDistribution.absoluteFrequency}</td>
						<td>{frequencyDistribution.relativeFrequency}</td>
					</tr>
				))}
				<tr>
					<td>Общо:</td>
					<td>{frequencyData.totalAbsoluteFrequency}</td>
					<td>{frequencyData.totalRelativeFrequency}</td>
				</tr>
			</table>
		</div>
	);
};

export default FrequencyDistribution;
