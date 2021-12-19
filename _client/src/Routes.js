import React from "react";
import { Route, Switch } from "react-router-dom";
import Home from "./containers/home/Home";
import NotFound from "./containers/not-found/NotFound";

export default function Routes() {
  return (
    <Switch>
      <Route exact path="/">
        <Home />
        {/* <NotFound /> */}
      </Route>
    </Switch>
  );
}
