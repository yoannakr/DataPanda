import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import "App.css";
import Menu from "components/Menu/Menu";
import FileUploader from "./components/FileUploader/FileUploader";
import FrequencyDistribution from "./components/FrequencyDistribution/FrequencyDistribution";
import CentralTrend from "./components/CentralTrend/CentralTrend";
import ScatteringMeasures from "./components/ScatteringMeasures/ScatteringMeasures";
import CorrelationAnalysis from "./components/CorrelationAnalysis/CorrelationAnalysis";

function App() {
	return (
		<Router>
			<Switch>
				<Route path="/" exact component={Menu} />
				<Route path="/fileUploader" exact component={FileUploader} />
				<Route path="/frequencyDistribution" exact component={FrequencyDistribution} />
				<Route path="/centralTrend" exact component={CentralTrend} />
				<Route path="/scatteringMeasures" exact component={ScatteringMeasures} />
				<Route path="/correlationAnalysis" exact component={CorrelationAnalysis} />
			</Switch>
		</Router>
	);
}

export default App;
