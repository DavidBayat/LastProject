import React, {useEffect, useState} from 'react';
import './App.css';
import RecipesBoard from "../RecipesBoard";
import IRecipes from "../../Interfaces";

function App() {
    const [recipeList, setRecipeList] = useState<IRecipes[]>([]);
    const [searchTerm, setSearchTerm] = useState("");

    const fetchRecipes = async () => {
        const response = await fetch("https://www.themealdb.com/api/json/v1/1/filter.php?i=");
        const data = await response.json();
        const { meals } = data;
        setRecipeList(meals);
    }
    useEffect(() => {
        fetchRecipes();
    },[]);
    
    return (
    <main>
      <RecipesBoard items={recipeList} />  
    </main>
  );
}

export default App;
