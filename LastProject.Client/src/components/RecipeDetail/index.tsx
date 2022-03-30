import React, { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import {IRecipe} from "../../Interfaces";

function SingleDish() {
    const { id } = useParams();
    const [singleDish, setSingleDish] = useState<IRecipe>();
    const getDish = async () => {
        try {
            const response = await fetch(`https://www.themealdb.com/api/json/v1/1/lookup.php?i=${id}`);
            const data = await response.json();
            const { meals } = data;
            if (meals) {
                const {
                    strMeal: name,
                    strCategory: category,
                    strArea: location,
                    strInstructions: instruction,
                    strTags: tags,
                    strMealThumb: image,
                    strYoutube: youtube,
                    strIngredient1,
                    strIngredient2,
                    strIngredient3,
                    strIngredient4,
                    strIngredient5,
                    strIngredient6,
                    strIngredient7,
                    strIngredient8,
                    strIngredient9,
                    strIngredient10,
                    strIngredient11,
                    strIngredient12,
                    strIngredient13,
                    strIngredient14,
                    strIngredient15,
                    strIngredient16,
                    strIngredient17,
                    strIngredient18,
                    strIngredient19,
                    strIngredient20,
                } = meals[0];
                const ingredients = [
                    strIngredient1,
                    strIngredient2,
                    strIngredient3,
                    strIngredient4,
                    strIngredient5,
                    strIngredient6,
                    strIngredient7,
                    strIngredient8,
                    strIngredient9,
                    strIngredient10,
                    strIngredient11,
                    strIngredient12,
                    strIngredient13,
                    strIngredient14,
                    strIngredient15,
                    strIngredient16,
                    strIngredient17,
                    strIngredient18,
                    strIngredient19,
                    strIngredient20,
                ].filter( item => {
                    return item !== null && item !== "";
                });
                const newDish = {
                    name,
                    category,
                    location,
                    instruction,
                    tags,
                    image,
                    youtube,
                    ingredients,
                };
                setSingleDish(newDish);
                console.log(newDish);
            } 
        } catch (error) {
            console.log(error);
        }
    };

    useEffect(() => {
        getDish();
    }, [id]);
   
    if (!singleDish) {
        return <h2 className="section-title">No dish to display</h2>;
    } else {
        const {
            name,
            category,
            location,
            instruction,
            tags,
            image,
            ingredients,
            youtube,
        } = singleDish;
        return (
            <section>
                <Link to="/">
                    back home
                </Link>
                <h2>{name}</h2>
                <div>
                    <img src={image} alt={name} />

                    <div>
                        <p>
                            <span>name:</span> {name}
                        </p>
                        <p>
                            <span>category:</span> {category}
                        </p>
                        <p>
                            <span>country:</span> {location}
                        </p>
                        <p>
                            <span>tags:</span> {tags ? tags : "meal"}
                        </p>
                    </div>
                </div>
            
            </section>
        );
    }
}
export default SingleDish;
