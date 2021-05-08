import React, { useState } from "react";
import axios from "axios";
import MenuButton from "components/common/Button/MenuButton/MenuButton";
import styles from "./CentralTrend.module.scss";

export class CentralTrendData {
	mode: number = 0;

	modeFrequency: number = 0;

	median: number = 0;

	average: number = 0;

	averageWithWeight: number = 0;
}

const CentralTrend = () => {
	const [platformNameInput, setPlatformName] = useState("");
	const [courseNameInput, setCourseName] = useState("");
	const [centralTrendData, setCentralTrendData] = useState<CentralTrendData>(new CentralTrendData());

	const onNameOfPlatformChange = (name: string) => {
		setPlatformName(name);
	};

	const onNameOfCourseChange = (name: string) => {
		setCourseName(name);
	};

	const getCentralTrend = () => {
		if (platformNameInput === "" || courseNameInput === "") {
			alert("Попълни данните!");
			return;
		}

		axios.get(`https://localhost:44364/api/statistics/CentralTrend?courseName=${courseNameInput}&platformName=${platformNameInput}`)
			.then(response => {
				const newCentralTrendData: CentralTrendData = Object.assign(new CentralTrendData(), response.data);
				setCentralTrendData(newCentralTrendData);
			})
			.catch(() => {
				alert("Неуспешно!");
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
				<button type="button" className={styles.GetButton} onClick={getCentralTrend}>Вземане на данни</button>
			</div>
			<table className={styles.Table}>
				<tr>
					<th>Мода</th>
					<th>Честота на модата</th>
					<th>Медиана</th>
					<th>Средна стойност</th>
					<th>Средна стойност с тегла</th>
				</tr>
				<tr>
					<td>{centralTrendData.mode}</td>
					<td>{centralTrendData.modeFrequency}</td>
					<td>{centralTrendData.median}</td>
					<td>{centralTrendData.average}</td>
					<td>{centralTrendData.averageWithWeight}</td>
				</tr>
			</table>
		</div>
	);
};

export default CentralTrend;
