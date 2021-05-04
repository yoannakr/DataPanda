import React from "react";
import styles from "./FormData.module.scss";
import { platformTypes } from "../../../models/platformType";
import { fieldOfApplications } from "../../../models/fieldOfApplication";

const FormData = () => (
	<form className={styles.Form}>
		<div className={styles.Row}>
			<div className={styles.Column}>
				<span>Име на платформата</span>
				<input type="text" placeholder="Име на платформата" />
			</div>
			<div className={styles.Column}>
				<span>Тип на платформата</span>
				<select id="platformType" name="platformType">
					{platformTypes.map(platformType => (
						<option key={platformType.id} value={platformType.name}>{platformType.name}</option>))}
				</select>
			</div>
			<div className={styles.Column}>
				<span>URL</span>
				<input type="text" placeholder="URL" />
			</div>
		</div>
		<div className={styles.Row}>
			<div className={styles.Column}>
				<span>Име на дисциплината</span>
				<input type="text" placeholder="Име на дисциплината" />
			</div>
			<div className={styles.Column}>
				<span>Област на приложение</span>
				<select id="fieldOfApplication" name="fieldOfApplication">
					{fieldOfApplications.map(fieldOfApplication => (
						<option key={fieldOfApplication.id} value={fieldOfApplication.name}>
							{fieldOfApplication.name}
						</option>
					))}
				</select>
			</div>
		</div>
	</form>
);

export default FormData;
