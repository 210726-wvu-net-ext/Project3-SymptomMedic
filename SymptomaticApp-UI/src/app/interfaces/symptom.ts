import { Doctor } from "./doctor";

export interface Symptom {
  id: number,
  symptom: string,
  doctorId: number,
  doctor: Doctor
}
