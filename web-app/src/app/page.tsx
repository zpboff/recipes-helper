import { RecipesList } from "@/app/features/recipe-list";
import { RecommendationBlock } from "@/app/features/recommendations-block";
import { PageLayout } from "@/app/layouts/page-layout/ui";
import styles from './page.module.css';

export const metadata = {
    title: 'Главная - Подбор рецептов',
    description: 'Поиск рецептов по ингредиентам',
}

export default function Home() {
  return (
      <PageLayout>
          <main className={styles.page}>
              <RecommendationBlock />
              <RecipesList />
              <div style={{ padding: "15px", backgroundColor: "lightgrey" }}>
                Deploy from docker registry
              </div>
          </main>
      </PageLayout>
  )
}