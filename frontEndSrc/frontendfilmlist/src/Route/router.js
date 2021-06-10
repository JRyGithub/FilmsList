import React from 'react';
import {Route, Switch} from 'react-router-dom';
import SignIn from '../Views/signIn.js';
import FilmList from '../Views/filmList.js';

export const MyRouter = () => {
    return (
        <Switch>
            <Route path='/signIn'>
                <SignIn/>
            </Route>
            <Route path='/filmList/:userEmail/:token'>
                <FilmList/>
            </Route> 
            <Route path='/'>
                <SignIn/>
            </Route>
        </Switch>
    )
}

export default MyRouter