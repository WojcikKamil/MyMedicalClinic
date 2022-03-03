import { Photo } from "./photo";

export interface Member {
  id: string;
  name: string;
  userName: string;
  lastName: string;
  adress: string;
  phoneNumber: number;
  specialization: string;
  academicDegree: string;
  introduction: string;
  photoUrl: string;
  photos: Photo[];

  secondName: string;
  idCard: string;
  passportCard: string;
  gender: string;
  birthDate: Date;
  birthPlace: string;
  voivodeship: string;
  pesel: string;
  nationality: string;
  motherName: string;
  fatherName: string;
  country: string;
  street: string;
  city: string;
  homeNumber: number;
  flatNumber: number;

  lifeDisease: string;
  treatments: string;
  allergies: string;
  bloodGroup: string;
  medicationsTakenPernamently: string;
  question1: string;
  question2: string;
  question3: string;
  question4: string;
  question5: string;
  question6: string;
  nfZward: string;
  employer: string;
  policyAgreement: string;

  university: string;
  postgraduateEducation: string;
  seniority: string;
  graduationTime : Date;
}
