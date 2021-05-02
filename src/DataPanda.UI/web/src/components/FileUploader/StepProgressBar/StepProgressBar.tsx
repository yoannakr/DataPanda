import React from "react";
import styles from "./StepProgressBar.module.scss";

interface IProps {
	countOfSteps: number;
	currentStep: number;
}

const StepProgressBar: React.FC<IProps> = ({ countOfSteps, currentStep }) => {
	const steps = [];
	for (let i = 0; i < countOfSteps; i += 1) {
		steps.push(<li className={i <= currentStep - 1 ? styles.Active : ""} />);
	}
	return (
		<div className={styles.Container}>
			<ul className={styles.ProgressBar}>
				{steps}
			</ul>
		</div>
	);
};

export default StepProgressBar;
