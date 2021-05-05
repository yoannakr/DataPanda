import React, { useState } from "react";
import { fileOptions, IOption } from "models/option";
import { platformTypes } from "models/platformType";
import { fieldOfApplications } from "models/fieldOfApplication";
import { IEnrolment } from "../../models/enrolment";
import styles from "./FileUploader.module.scss";
import StepProgressBar from "./StepProgressBar/StepProgressBar";
import FormData from "./FileFormData/FileFormData";
import FileOption from "./FileOption/FileOption";
import FileSelection from "./FileSelection/FileSelection";

const FileUploader = () => {
	const [currentStep, setCurrentStep] = useState(1);
	const [selectedOption, setSelectedOption] = useState<IOption>();
	const [enrolment, setEnrolment] = useState<IEnrolment>();
	const defaultEnrolment: IEnrolment = { typeOfPlatform: platformTypes[0], fieldOfApplication: fieldOfApplications[0] };
	const result = [];
	const countOfSteps = 3;

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
					<FormData enrolment={enrolment} updateEnrolment={updateEnrolment} />
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
			{currentStep <= countOfSteps - 1 ? <button type="button" onClick={incrementStep} className={styles.Next}>Напред</button> : ""}
		</div>
	);

	return <div>{result}</div>;
};

export default FileUploader;
