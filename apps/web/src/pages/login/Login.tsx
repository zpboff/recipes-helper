import { LoginByEmailForm } from "@/features/auth/by-email";

export const metadata = {
    title: 'Вход - Подбор рецептов',
    description: 'Вход',
}

export default function Login() {    
    return (
        <div>
            <h1>Вход</h1>
            <LoginByEmailForm />
        </div>
    );
}