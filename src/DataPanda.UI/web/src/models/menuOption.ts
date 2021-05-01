export interface IMenuOption {
	id: number;
	name: string;
}

export const menuOptions: IMenuOption[] = [{
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
