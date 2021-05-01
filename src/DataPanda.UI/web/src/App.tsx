import React from 'react';
import './App.css';
import Menu from "../src/components/Menu/Menu";
import { menuOptions } from "../src/models/menuOption";

function App() {
  return (
    <div>
      < Menu menuOptions={menuOptions} />
    </div>
  );
}

export default App;
