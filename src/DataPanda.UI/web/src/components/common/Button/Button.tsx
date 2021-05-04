import React from "react";
import styles from "./Button.module.scss";

interface IProps {
	content: string;
}

const Button: React.FC<IProps> = ({ content }) => (
	<button type="button" className={styles.Button}>{content}</button>
);

export default Button;
