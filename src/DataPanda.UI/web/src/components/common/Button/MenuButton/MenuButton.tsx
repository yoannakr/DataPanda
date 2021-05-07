import React from "react";
import { Link } from "react-router-dom";
import styles from "./MenuButton.module.scss";

const MenuButton = () => (
	<Link to="/"><button type="button" className={styles.MenuButton}>Меню</button></Link>
);

export default MenuButton;
