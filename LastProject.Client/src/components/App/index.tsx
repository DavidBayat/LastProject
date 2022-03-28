import React, {useEffect, useState} from 'react';
import './App.css';
import RecipesBoard from "../RecipesBoard";

function App() {
    const [recipeList, setRecipeList] = useState([]);
    const [searchTerm, setSearchTerm] = useState("");

    const fetchRecipes = async () => {
        const response = await fetch("https://www.themealdb.com/api/json/v1/1/filter.php?i=");
        const data = await response.json();
        const { meals } = data;
        setRecipeList(meals);
        console.log(meals.length)
    }
    useEffect(() => {
        fetchRecipes();
    },[]);
    
    return (
    <>
      <p>number of Recipes: {recipeList.length}</p>  
      <RecipesBoard />  
    </>
  );
}

export default App;
