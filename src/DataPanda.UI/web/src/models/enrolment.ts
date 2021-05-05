import {IPlatformType} from "./platformType";
import {IFieldOfApplication} from "./fieldOfApplication";
import {IFile} from "./file";

export interface IEnrolment {
	nameOfPlatform: string;
	typeOfPlatform: IPlatformType;
	url: string;
	nameOfCourse: string;
	fieldOfApplication: IFieldOfApplication;
	files: IFile[];
}
