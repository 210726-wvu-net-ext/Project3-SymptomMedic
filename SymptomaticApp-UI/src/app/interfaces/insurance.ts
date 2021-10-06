import { Client } from "./client";

export interface Insurance
{
  id: number,
  providerName: string,
  providerId: string,
  clients: Client[]
}
