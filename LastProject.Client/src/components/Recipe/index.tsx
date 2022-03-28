import React from 'react';
import IRecipes from "../../Interfaces";
interface Props {
    item: IRecipes
}

const Recipe = ({item} : Props) => {
    const { idMeal, strMeal, strMealThumb} = item
    return (
        <article>
            <img src={strMealThumb} alt={strMeal} />
            <h3>{strMeal}</h3>
            <p>{strMealThumb}</p> 
        </article>
    );
};

export default Recipe;
