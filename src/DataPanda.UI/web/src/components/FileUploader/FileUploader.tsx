import React, { useState } from "react";
import axios from "axios";
import { fileOptions, IOption } from "models/option";
import { platformTypes } from "models/platformType";
import { fieldOfApplications } from "models/fieldOfApplication";
import { useHistory } from "react-router-dom";
import MenuButton from "components/common/Button/MenuButton/MenuButton";
import { IEnrolment } from "../../models/enrolment";
import styles from "./FileUploader.module.scss";
import StepProgressBar from "./StepProgressBar/StepProgressBar";
import FileFormData from "./FileFormData/FileFormData";
import FileOption from "./FileOption/FileOption";
import FileSelection from "./FileSelection/FileSelection";

const FileUploader = () => {
	const [currentStep, setCurrentStep] = useState(1);
	const [selectedOption, setSelectedOption] = useState<IOption>();
	const defaultEnrolment: IEnrolment = {
		nameOfPlatform: "",
		typeOfPlatform: platformTypes[0],
		url: "",
		nameOfCourse: "",
		fieldOfApplication: fieldOfApplications[0],
		files: []
	};
	const [enrolment, setEnrolment] = useState<IEnrolment>(defaultEnrolment);
	const result = [];
	const countOfSteps = 3;
	const history = useHistory();

	if (enrolment === undefined) {
		setEnrolment(defaultEnrolment);
	}

	if (selectedOption === undefined) {
		setSelectedOption(fileOptions[0]);
	}

	const decrementStep = () => {
		if (currentStep !== 1) {
			setCurrentStep(currentStep - 1);
		}
	};

	const incrementStep = () => {
		if (currentStep !== countOfSteps) {
			setCurrentStep(currentStep + 1);
		}
	};

	const selectOption = (id: number) => {
		setSelectedOption(fileOptions.find(op => op.id === id));
	};

	const updateEnrolment = (newEnrolment: IEnrolment) => {
		setEnrolment(newEnrolment);
	};

	const uploadEnrolment = () => {
		if (enrolment.nameOfPlatform === "" || enrolment.typeOfPlatform.name === ""
			|| enrolment.url === "" || enrolment.nameOfCourse === "" || enrolment.fieldOfApplication.name === ""
			|| enrolment.files.length === 0) {
			alert("Попълнете данните!");
			return;
		}

		if (selectedOption?.id === 1) {
			const paramsInput = new FormData();
			paramsInput.append("PlatformName", enrolment.nameOfPlatform);
			paramsInput.append("PlatformType", enrolment.typeOfPlatform.name);
			paramsInput.append("PlatformUrl", enrolment.url);
			paramsInput.append("CourseName", enrolment.nameOfCourse);
			paramsInput.append("CourseFieldOfApplication", enrolment.fieldOfApplication.name);
			paramsInput.append("FormFile", enrolment.files[0].content);

			axios.post("https://localhost:44364/api/file/Upload", paramsInput);
		} else if (selectedOption?.id === 2) {
			const paramsInput = new FormData();
			paramsInput.append("PlatformName", enrolment.nameOfPlatform);
			paramsInput.append("PlatformType", enrolment.typeOfPlatform.name);
			paramsInput.append("PlatformUrl", enrolment.url);
			paramsInput.append("CourseName", enrolment.nameOfCourse);
			paramsInput.append("CourseFieldOfApplication", enrolment.fieldOfApplication.name);
			enrolment.files.map(file => paramsInput.append("FormFiles", file.content));

			axios.post("https://localhost:44364/api/file/UploadMultiple", paramsInput);
		} else if (selectedOption?.id === 3) {
			const paramsInput = new FormData();
			paramsInput.append("PlatformName", enrolment.nameOfPlatform);
			paramsInput.append("PlatformType", enrolment.typeOfPlatform.name);
			paramsInput.append("PlatformUrl", enrolment.url);
			paramsInput.append("CourseName", enrolment.nameOfCourse);
			paramsInput.append("CourseFieldOfApplication", enrolment.fieldOfApplication.name);
			paramsInput.append("FormFile", enrolment.files[0].content);

			axios.post("https://localhost:44364/api/file/UploadArchive", paramsInput);
		}

		history.push("/");
	};

	result.push(<MenuButton />);

	switch (currentStep) {
		case 1:
			result.push(
				<div key={currentStep}>
					<StepProgressBar countOfSteps={countOfSteps} currentStep={1} />
					<FileOption fileOptions={fileOptions} selectOption={selectOption} selectedOption={selectedOption} />
				</div>
			);
			break;
		case 2:
			result.push(
				<div key={currentStep}>
					<StepProgressBar countOfSteps={countOfSteps} currentStep={2} />
					<FileFormData enrolment={enrolment} updateEnrolment={updateEnrolment} />
				</div>
			);
			break;
		case 3:
			result.push(
				<div key={currentStep}>
					<StepProgressBar countOfSteps={countOfSteps} currentStep={3} />
					<FileSelection enrolment={enrolment} updateEnrolment={updateEnrolment} selectedOption={selectedOption} />
				</div>
			);
			break;
		default:
			break;
	}
	result.push(
		<div className={styles.Button} key={countOfSteps + 1}>
			{currentStep > 1 ? <button type="button" onClick={decrementStep} className={styles.Previous}>Назад</button> : ""}
			{currentStep <= countOfSteps - 1
				? <button type="button" onClick={incrementStep} className={styles.Next}>Напред</button>
				: <button type="button" onClick={uploadEnrolment} className={styles.Next}>Завърши</button>}
		</div>
	);

	return <div>{result}</div>;
};

export default FileUploader;
