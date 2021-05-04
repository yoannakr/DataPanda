import {IPlatformType} from "./platformType";
import {IFieldOfApplication} from "./fieldOfApplication";

export interface IEnrolment {
	nameOfPlatform?: string;
	typeOfPlatform?: IPlatformType;
	url?: string;
	nameOfCourse?: string;
	fieldOfApplication?: IFieldOfApplication;
}
