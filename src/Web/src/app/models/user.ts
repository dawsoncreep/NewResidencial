import { Role } from './role';

export class User {
    Id: number;
    UserName: String;
    Email: string;
    Role : Role;
    Permisions : string[];
    Token: string;
}