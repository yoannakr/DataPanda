export interface IOption {
	id: number;
	name: string;
}

export const menuOptions: IOption[] = [{
	id: 1,
	name: "Четене и обобщаване на данните от файлове с дейности и оценки"
},
{
	id: 2,
	name: "Честотно разпределение на изпълнени и качени курсови задачи и проекти"
},
{
	id: 3,
	name: "Определяне на мерки на централната тенденция за изпълнени и качени курсови задачи и проекти"
},
{
	id: 4,
	name: "Мерки на разсейване за изпълнени и качени курсови задачи и проекти"
},
{
	id: 5,
	name: "Корелационен анализ на брой редактирани Wiki"
}
];

export const fileOptions: IOption[] = [{
	id: 1,
	name: "Качване на един файл"
},
{
	id: 2,
	name: "Качване на няколко файла"
},
{
	id: 3,
	name: "Качване на архив от файлове"
}
];
