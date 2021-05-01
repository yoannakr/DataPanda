import React from "react";
import { IMenuOption } from "models/menuOption";
import styles from "./Menu.module.scss";

interface IProps {
	menuOptions: IMenuOption[];
}

const Menu : React.FC<IProps> = ({ menuOptions }) => (
	<div className={styles.Menu}>
		{menuOptions.map(option => (
			<button type="button" className={styles.Button} key={option.id}>{option.name}</button>
		))}
	</div>
);

export default Menu;
