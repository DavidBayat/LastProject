import React, {useCallback, useEffect, useState} from 'react';
import RecipesBoard from "../RecipesBoard";
import IRecipes from "../../Interfaces";
import SearchForm from "../SearchForm";

function Home() {
    const [recipeList, setRecipeList] = useState<IRecipes[]>([]);
    const [searchTermOne, setSearchTermOne] = useState("");
    const [searchTermTwo, setSearchTermTwo] = useState("");
    const [searchTermThree, setSearchTermThree] = useState("");

    const fetchRecipes = useCallback(async () => {
        const response = await fetch(`https://www.themealdb.com/api/json/v1/1/filter.php?i=${searchTermOne}`);
        const data = await response.json();
        const { meals } = data;
        if(meals)
        {
            setRecipeList(meals);
        } else
        {
            setRecipeList([]);
        }
    }, [searchTermOne])

    useEffect(() => {
        fetchRecipes();
    },[searchTermOne, fetchRecipes]);

    return (
        <main>
            <SearchForm setSearchTermOne={setSearchTermOne} setSearchTermTwo={setSearchTermTwo} setSearchTermThree={setSearchTermThree} />
            <RecipesBoard items={recipeList} />
        </main>
    );
}

export default Home;
