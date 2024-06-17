import axios from "axios";
import { Maybe } from "@/core/utils/maybe";
import { Recipe } from "@/domain/models/recipe/model";
import { IRecipeRepository } from "@/domain/repositories/IRecipeRepository";

const ITEMS_PER_PAGE = 9;

type Response = {
    recipes: Recipe[];
}

async function getRecipes(page: number) {
    const { data: { recipes } } = await axios.get<Response>("https://api.spoonacular.com/recipes/random", {
        params: {
            apiKey: process.env.SPOONACULAR_API_KEY,
            number: ITEMS_PER_PAGE
        }
    });

    const result: Maybe<Recipe[]> = Maybe.from(recipes);

    return result;
}

async function getRecipe(id: string) {
    const { data } = await axios.get<Recipe>(`https://api.spoonacular.com/recipes/${id}/information`, {
        params: {
            apiKey: process.env.SPOONACULAR_API_KEY
        }
    });

    const result: Maybe<Recipe> = Maybe.from(data);

    return result;
}

async function createRecipe(recipe: Recipe) {
    return Maybe.nothing<string>();
}

async function updateRecipe(recipe: Recipe) {
    return Maybe.nothing<boolean>();
}

async function deleteRecipe(id: string) {
    return Maybe.nothing<boolean>();
}

export const recipesRepository: IRecipeRepository = {
    getRecipes,
    getRecipe,
    createRecipe,
    deleteRecipe,
    updateRecipe,
}