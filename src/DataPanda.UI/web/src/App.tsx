import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import "App.css";
import Menu from "components/Menu/Menu";
import FileUploader from "./components/FileUploader/FileUploader";

function App() {
	return (
		<Router>
			<Switch>
				<Route path="/" exact component={Menu} />
				<Route path="/fileUploader" exact component={FileUploader} />
			</Switch>
		</Router>
	);
}

export default App;
