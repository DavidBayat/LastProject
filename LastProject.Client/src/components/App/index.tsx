import React from 'react';
import {BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import Home from "../Home";
import RecipeDetail from "../RecipeDetail";

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/recipe/:id" element={<RecipeDetail />} />
            </Routes>
        </Router>
    );
};

export default App;
