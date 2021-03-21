export interface Book {
  id:string;
  name:string;
  author:string;
}

export interface AuthRequest{
  email:string;
  password:string;
}

export interface AuthResponse {
  userId: string;
  token: string;
  wasRegistered: boolean;
}
