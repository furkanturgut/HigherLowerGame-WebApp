import axios from 'axios';
import { PlayerSearch } from './player';

export const searchPlayer = async (pageNumber: number = 1, pageSize: number = 10) => {
  const response = await axios.get<PlayerSearch[]>(
    `http://localhost:5043/api/Player?PageNumber=${pageNumber}&PageSize=${pageSize}`
  );
  return response;
};
