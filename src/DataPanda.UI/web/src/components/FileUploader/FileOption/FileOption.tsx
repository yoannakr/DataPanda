import React from "react";
import styles from "./FileOption.module.scss";
import { IOption } from "../../../models/option";
import Button from "../../common/Button/Button";

interface IProps {
	fileOptions: IOption[];
}

const FileOption: React.FC<IProps> = ({ fileOptions }) => (
	<div className={styles.Container}>
		{fileOptions.map(option => (
			<Button key={option.id} content={option.name} />
		))}
	</div>
);

export default FileOption;
