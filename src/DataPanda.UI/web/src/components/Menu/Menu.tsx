import React from "react";
import styles from "../Menu/Menu.module.scss";
const Menu = () => {
    let menuOptions = ["Четене и обобщаване на данните от файлове с дейности и оценки", 
    "Честотно разпределение на изпълнени и качени курсови задачи и проекти",
    "Определяне на мерки на централната тенденция за изпълнени и качени курсови задачи и проекти",
    "Мерки на разсейване за изпълнени и качени курсови задачи и проекти",
    "Корелационен анализ на брой редактирани Wiki"];

    return(
    <div className={styles.Menu}>
        {menuOptions.map((option) => (
            <button type="button" className={styles.Button}>{option}</button>
        ))};
    </div>
  )};
  
  export default Menu;