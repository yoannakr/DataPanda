import React from "react";
import { Link } from "react-router-dom";
import { menuOptions } from "models/option";
import styles from "./Menu.module.scss";
import Button from "../common/Button/Button";

const Menu = () => (
	<div className={styles.Menu}>
		{menuOptions.map(option => (
			<Link to={option.path} className={styles.Link}>
				<Button key={option.id} content={option.name} />
			</Link>
		))}
	</div>
);

export default Menu;
