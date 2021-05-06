import React from "react";
import MenuButton from "components/common/Button/MenuButton/MenuButton";
import styles from "./FrequencyDistribution.module.scss";

const FrequencyDistribution = () => (
	<div>
		<MenuButton />
		<table className={styles.Table}>
			<tr>
				<th>Име на платформа</th>
				<th>Име на дисциплина</th>
				<th>Абсолютна честота</th>
				<th>Относителна честота</th>
			</tr>
			<tr>
				<td>Alfreds Futterkiste</td>
				<td>Maria Anders</td>
				<td>Germany</td>
				<td>Germany</td>
			</tr>
			<tr>
				<td>Centro comercial Moctezuma</td>
				<td>Francisco Chang</td>
				<td>Mexico</td>
				<td>Mexico</td>
			</tr>
		</table>
	</div>
);

export default FrequencyDistribution;
