import React from 'react';
import IRecipes from "../../Interfaces";
import './Recipe.css'

interface Props {
    item: IRecipes
}

const Recipe = ({item} : Props) => {
    const { idMeal, strMeal, strMealThumb} = item
    return (
        <article className="recipe">
            <img src={strMealThumb} alt={strMeal} />
            <h3>{strMeal}</h3>
        </article>
    );
};

export default Recipe;
