import React, { ChangeEvent, useState, useEffect } from "react";
import { IEnrolment } from "models/enrolment";
import { IOption } from "models/option";
import { IFile } from "../../../models/file";
import styles from "./FileSelection.module.scss";

interface IProps {
	enrolment: IEnrolment | undefined;
	updateEnrolment: any;
	selectedOption: IOption | undefined;
}

const FileSelection: React.FC<IProps> = ({ enrolment, updateEnrolment, selectedOption }) => {
	const [newEnrolment, setNewEnrolment] = useState(enrolment);
	const fileProps = { accept: "", multiple: false };

	useEffect(() => {
		updateEnrolment(newEnrolment);
	}, [newEnrolment]);

	if (selectedOption?.id === 1) {
		fileProps.accept = ".xls,.xlsx";
		fileProps.multiple = false;
	} else if (selectedOption?.id === 2) {
		fileProps.accept = ".xls,.xlsx";
		fileProps.multiple = true;
	} else if (selectedOption?.id === 3) {
		fileProps.accept = ".zip,.rar,.7zip";
		fileProps.multiple = false;
	}

	const selectFile = (event: ChangeEvent<HTMLInputElement>) => {
		const eventFiles = event.target.files != null ? event.target.files : [];
		const newFiles: IFile[] = [];
		for (let i = 0; i < eventFiles.length; i += 1) {
			const newFile = { id: i, name: eventFiles[i].name, content: eventFiles[i] };
			newFiles.push(newFile);
		}
		setNewEnrolment({ ...newEnrolment, files: newFiles });
	};

	const clearFiles = () => {
		setNewEnrolment({ ...newEnrolment, files: [] });
	};

	return (
		<div className={styles.InputFile}>
			<input type="file" id="file" onChange={selectFile} onClick={clearFiles} {...fileProps} />
			<label htmlFor="file">Избиране на файл</label>
			<h4>Избраните файлове:</h4>
			{newEnrolment?.files?.map(file => (
				<p key={file.id}>{file.name}</p>
			))}
		</div>
	);
};

export default FileSelection;
