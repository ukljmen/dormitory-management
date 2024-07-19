export enum UserRole{
    Admin = 1,
    Manager,
    Conservator,
    Student
}

export const UserRoles: Record<string, UserRole> = {
    "Admin": 1,
    "Manager": 2,
    "Conservator": 3,
    "Student": 4
}