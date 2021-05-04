import React from "react";
import { IOption } from "models/option";
import styles from "./Menu.module.scss";
import Button from "../common/Button/Button";

interface IProps {
	menuOptions: IOption[];
}

const Menu: React.FC<IProps> = ({ menuOptions }) => (
	<div className={styles.Menu}>
		{menuOptions.map(option => (
			<Button key={option.id} content={option.name} />
		))}
	</div>
);

export default Menu;
