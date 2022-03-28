import React from 'react';
import IRecipes from "../../Interfaces";

interface Props {
    items: IRecipes[]
}

const RecipesBoard = ({ items } : Props) => {
    return (
        <>
            <h4> recipes board</h4>
            <p>number of Recipes: {items.length}</p>
            { items.map(item => {
                    return <p> {item.strMealThumb} </p>
                }
            ) }
        </>
    );
};

export default RecipesBoard;
