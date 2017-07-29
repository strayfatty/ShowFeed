import Api from 'shared/api';
import Series from 'features/series/series';

export default class SeriesService {
  static details(seriesId: string): Promise<Series> {
    return Api.get<DetailsResponse>('series/' + seriesId)
      .then(x => x.series);
  }

  static list(filter: string, skip: number, take: number): Promise<Series[]> {
    const query = { filter: filter, skip: skip, take: take };
    return Api.get<ListResponse>('series', query)
      .then(x => x.items);
  }
}

interface DetailsResponse {
  series: Series;
}

interface ListResponse {
  items: Series[];
}