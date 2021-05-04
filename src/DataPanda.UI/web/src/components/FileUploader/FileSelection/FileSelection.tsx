import { IOption } from "models/option";
import React, { ChangeEvent, useState } from "react";
import styles from "./FileSelection.module.scss";

interface IFile {
	id: number;
	name: string;
}

interface IProps {
	selectedOption: IOption | undefined;
}
const FileSelection: React.FC<IProps> = ({ selectedOption }) => {
	const [selectedFiles, setSelectedFiles] = useState<IFile[]>([]);
	const fileProps = { accept: "", multiple: false };

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
		const eventFiles = event.currentTarget.files != null ? event.currentTarget.files : [];
		const files: IFile[] = [];
		for (let i = 0; i < eventFiles.length; i += 1) {
			const newFile = { id: selectedFiles.length + 1, name: eventFiles[i].name };
			files.push(newFile);
		}
		setSelectedFiles(files);
	};

	const clearFiles = () => {
		setSelectedFiles([]);
	};

	return (
		<div className={styles.InputFile}>
			<input type="file" id="file" onChange={selectFile} onClick={clearFiles} {...fileProps} />
			<label htmlFor="file">Избиране на файл</label>
			<h4>Избраните файлове:</h4>
			{selectedFiles.map(file => (
				<p key={file.id}>{file.name}</p>
			))}
		</div>
	);
};

export default FileSelection;
