import React, { useState, useEffect } from "react";
import { IEnrolment } from "models/enrolment";
import styles from "./FileFormData.module.scss";
import { IPlatformType, platformTypes } from "../../../models/platformType";
import { fieldOfApplications, IFieldOfApplication } from "../../../models/fieldOfApplication";

interface IProps {
	enrolment: IEnrolment | undefined;
	updateEnrolment: any;
}

const FormData: React.FC<IProps> = ({ enrolment, updateEnrolment }) => {
	const [newEnrolment, setNewEnrolment] = useState(enrolment);

	useEffect(() => {
		updateEnrolment(newEnrolment);
	}, [newEnrolment]);

	const onNameOfPlatformChange = (name: string) => {
		setNewEnrolment({ ...newEnrolment, nameOfPlatform: name });
	};

	const onPlatformTypeChange = (id: number) => {
		const platformType: IPlatformType | undefined = platformTypes.find(p => p.id === id);
		setNewEnrolment({ ...newEnrolment, typeOfPlatform: platformType });
	};

	const onFieldOfApplicationChange = (id: number) => {
		const fieldApp: IFieldOfApplication | undefined = fieldOfApplications.find(p => p.id === id);
		setNewEnrolment({ ...newEnrolment, fieldOfApplication: fieldApp });
	};

	const onURLChange = (urlInput: string) => {
		setNewEnrolment({ ...newEnrolment, url: urlInput });
	};

	const onNameOfCourseChange = (name: string) => {
		setNewEnrolment({ ...newEnrolment, nameOfCourse: name });
	};

	return (
		<div className={styles.Form}>
			<div className={styles.Row}>
				<div className={styles.Column}>
					<span>Име на платформата</span>
					<input type="text" placeholder="Име на платформата" value={newEnrolment?.nameOfPlatform} onChange={e => onNameOfPlatformChange(e.currentTarget.value)} />
				</div>
				<div className={styles.Column}>
					<span>Тип на платформата</span>
					<select id="platformType" name="platformType" onChange={e => onPlatformTypeChange(+e.target.value)}>
						{platformTypes.map(platformType => (
							<option key={platformType.id} value={platformType.id} selected={newEnrolment?.typeOfPlatform?.id === platformType.id}>{platformType.name}</option>))}
					</select>
				</div>
				<div className={styles.Column}>
					<span>URL</span>
					<input type="text" placeholder="URL" value={newEnrolment?.url} onChange={e => onURLChange(e.currentTarget.value)} />
				</div>
			</div>
			<div className={styles.Row}>
				<div className={styles.Column}>
					<span>Име на дисциплината</span>
					<input type="text" placeholder="Име на дисциплината" value={newEnrolment?.nameOfCourse} onChange={e => onNameOfCourseChange(e.currentTarget.value)} />
				</div>
				<div className={styles.Column}>
					<span>Област на приложение</span>
					<select id="fieldOfApplication" name="fieldOfApplication" onChange={e => onFieldOfApplicationChange(+e.target.value)}>
						{fieldOfApplications.map(fieldOfApplication => (
							<option key={fieldOfApplication.id} value={fieldOfApplication.id} selected={newEnrolment?.fieldOfApplication?.id === fieldOfApplication.id}>
								{fieldOfApplication.name}
							</option>
						))}
					</select>
				</div>
			</div>
		</div>
	);
};

export default FormData;
