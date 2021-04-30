import React from "react";
import styles from "../Menu/Menu.module.scss";
import { IMenuOption } from "../../models/menuOption";

interface IProps {
    menuOptions: IMenuOption[];
}

const Menu : React.FC<IProps> = ({ menuOptions }) => {
    return(
    <div className={styles.Menu}>
        {menuOptions.map((option) => (
            <button type="button" className={styles.Button} key={option.id}>{option.name}</button>
        ))}
    </div>
  )};
  
  export default Menu;