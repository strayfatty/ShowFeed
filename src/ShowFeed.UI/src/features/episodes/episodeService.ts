import Api from 'shared/api';
import Episode from 'features/episodes/episode';

export default class EpisodeService {
  static list(seriesId: string, season?: number) {
    const query = { seriesId: seriesId, season: season };
    return Api.get<ListResponse>('episodes', query)
      .then(x => x.items);
  }
}

interface ListResponse {
  items: Episode[];
}