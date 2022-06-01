CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS profiles(
  id VARCHAR(255) NOT NULL primary key,
  name varchar(255) COMMENT 'Profile Name',
  picture varchar(255) COMMENT 'Profile Picture',
  creatorId VARCHAR(255) NOT NULL,

   FOREIGN KEY (creatorId)
    REFERENCES accounts(id)
    ON DELETE CASCADE

) default charset utf8;

CREATE TABLE IF NOT EXISTS follows(
  id VARCHAR(255) NOT NULL primary key,
  name varchar(255) COMMENT 'Follower Name',
  picture varchar(255) COMMENT 'Follower Picture',
  followerId VARCHAR(255) NOT NULL,

   FOREIGN KEY (followerId)
    REFERENCES accounts(id)
    ON DELETE CASCADE

) default charset utf8;

