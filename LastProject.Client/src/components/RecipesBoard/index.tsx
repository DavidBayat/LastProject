import React from 'react';
import IRecipes from "../../Interfaces";
import Recipe from "../Recipe";

interface Props {
    items: IRecipes[]
}

const RecipesBoard = ({ items } : Props) => {
    return (
        <section className="section">
            <h2>recipes board</h2>
            <p>number of Recipes: {items.length}</p>
            { items.map(item => {
                    return <Recipe key={item.idMeal} item={item} />
                }
            ) }
        </section>
    );
};

export default RecipesBoard;
