import React from "react";
import "App.css";
import Menu from "components/Menu/Menu";
import { menuOptions } from "models/menuOption";

function App() {
	return (
		<div>
			<Menu menuOptions={menuOptions} />
		</div>
	);
}

export default App;
