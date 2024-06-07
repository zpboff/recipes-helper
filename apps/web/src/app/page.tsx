import { PageLayout } from "@/app/layouts/page-layout/ui";
import { Button } from "@recipes-helper/shared-ui";
import styles from './page.module.css';

export const metadata = {
    title: 'Главная - Подбор рецептов',
    description: 'Поиск рецептов по ингредиентам',
}

export default function Home() {
  return (
      <PageLayout>
          <main className={styles.page}>
              <Button>1231232</Button>
          </main>
      </PageLayout>
  )
}
