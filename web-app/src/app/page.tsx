import { RecipesList } from './landing/RecipeList/RecipeList';
import { RecommendationBlock } from './landing/RecipeList/RecommendationBlock/RecommendationBlock';
import styles from './page.module.css';

export const metadata = {
    title: 'Главная - Подбор рецептов',
    description: 'Поиск рецептов по ингредиентам',
}

export default function Home() {
  return (
    <main className={styles.page}>
      <RecommendationBlock />
      <RecipesList />
    </main>
  )
}
