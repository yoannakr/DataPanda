import React from "react";
import styles from "./FileOption.module.scss";
import { IOption } from "../../../models/option";

interface IProps {
	fileOptions: IOption[];
	selectOption: any;
	selectedOption: IOption | undefined;
}

const FileOption: React.FC<IProps> = ({ fileOptions, selectOption, selectedOption }) => (
	<div className={styles.Container}>
		{fileOptions.map(option => (
			<div key={option.id} className={styles.FileOptions}>
				<input type="radio" id={option.name} name="fileOptions" value={option.id} onChange={() => selectOption(option.id)} checked={selectedOption?.id === option.id} />
				<label htmlFor={option.name} key={option.id}>
					{option.name}
				</label>
			</div>
		))}
	</div>
);

export default FileOption;
