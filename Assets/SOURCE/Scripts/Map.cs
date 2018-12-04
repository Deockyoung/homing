using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// map 의 속성을 갖는다.
// - tile 기반
// - tilex, tiley 갖는다.
public class Map : MonoBehaviour {

    public int tileX;
    public int tileY;

    // 바닥타일지정
    public GameObject floorTile;

    // 그려질 타일
    public GameObject selectedTile;
}
