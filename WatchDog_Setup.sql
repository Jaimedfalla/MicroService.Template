﻿ALTER TABLE WatchDog_Logs ALTER COLUMN callingMethod VARCHAR(MAX)
ALTER TABLE WatchDog_Logs ALTER COLUMN callingFrom VARCHAR(MAX)

ALTER TABLE WatchDog_WatchExceptionLog ALTER COLUMN typeOf VARCHAR(300)
ALTER TABLE WatchDog_WatchExceptionLog ALTER COLUMN path VARCHAR(MAX)
ALTER TABLE WatchDog_WatchExceptionLog ALTER COLUMN method VARCHAR(300)
ALTER TABLE WatchDog_WatchExceptionLog ALTER COLUMN queryString VARCHAR(MAX)
ALTER TABLE WatchDog_WatchExceptionLog ALTER COLUMN encounteredAt VARCHAR(MAX)

ALTER TABLE WatchDog_WatchLog ALTER COLUMN method VARCHAR(MAX)
ALTER TABLE WatchDog_WatchLog ALTER COLUMN method VARCHAR(300)